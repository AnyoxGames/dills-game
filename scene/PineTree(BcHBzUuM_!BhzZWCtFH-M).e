13
4866197946369
405103250170686 1761863345127063500
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 16.6940078735351562,
    "Y": -5.9878969192504883
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405100603592857:1761863344510408300",
  "next_sibling": "405104967613169:1761863345527229900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405103250412948:1761863345127119200",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "405103250542249:1761863345127149300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405103250412948:1761863345127119200",
    "DefaultRenderer": "405103250594193:1761863345127161400",
    "DepletedRenderer": "405103250577079:1761863345127157400"
  }
},
{
  "cid": 5,
  "aoid": "405103250555966:1761863345127152500",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}

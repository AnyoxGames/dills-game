13
867583393800
908793921444593 1761162255468498300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 11.2483777999877930,
    "Y": 0.6345186233520508
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "908793922426541:1761162255468727100",
  "next_sibling": "908793919746480:1761162255468102700",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "908793921721857:1761162255468562900",
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
  "aoid": "908793921737595:1761162255468566500",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "908793921721857:1761162255468562900",
    "DefaultRenderer": "908793921777499:1761162255468575800",
    "DepletedRenderer": "908793921788980:1761162255468578500"
  }
},
{
  "cid": 5,
  "aoid": "908793921745636:1761162255468568400",
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

13
4844723109889
405100603592857 1761863344510408300
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 15.6464242935180664,
    "Y": -7.4844441413879395
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405080504266670:1761863339827244600",
  "next_sibling": "405103250170686:1761863345127063500",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405100603836796:1761863344510464200",
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
  "aoid": "405100603959217:1761863344510492700",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405100603836796:1761863344510464200",
    "DefaultRenderer": "405100604012150:1761863344510505100",
    "DepletedRenderer": "405100603995337:1761863344510501100"
  }
},
{
  "cid": 5,
  "aoid": "405100603972547:1761863344510495900",
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

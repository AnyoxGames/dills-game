13
4629974745089
405050746843928 1761863332893734400
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": 9.2847309112548828,
    "Y": -11.9503831863403320
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "405048457841184:1761863332360394300",
  "next_sibling": "405053894836089:1761863333627220100",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "405050747078192:1761863332893787900",
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
  "aoid": "405050747205730:1761863332893817600",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "405050747078192:1761863332893787900",
    "DefaultRenderer": "405050747253460:1761863332893828700",
    "DepletedRenderer": "405050747236690:1761863332893824800"
  }
},
{
  "cid": 5,
  "aoid": "405050747217684:1761863332893820400",
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
